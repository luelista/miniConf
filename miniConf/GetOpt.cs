#region LICENSE
/* 
 * 
 * CpGetOpt - GetOpt Implementation for .NET
 * Copyright (C) 2008 Rodger Aiken <null.coded@gmail.com>
 * 
 * This library is free software; you can redistribute it and/or modify it under
 * the terms of the GNU Lesser General Public License as published by the Free
 * Software Foundation; either version 2.1 of the License, or (at your option)
 * any later version.
 * 
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License
 * for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with this library; if not, write to the Free Software Foundation, Inc.,
 * 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 * 
 */
#endregion

namespace CodePoints
{
	using System;

	/// <summary>
	/// Identifies optional settings to be applied when parsing program arguments.
	/// </summary>
	[Flags]
	public enum GetOptionsSettings
	{
		/// <summary>
		/// None; parse with default settings.
		/// </summary>
		None = 0,
		/// <summary>
		/// Maintain strict emulation of the glibc getopt implementation.
		/// </summary>
		GlibcCorrect = 0x01,
		/// <summary>
		/// Maintain strict emulation of the POSIX getopt implementation.
		/// </summary>
		PosixCorrect = 0x02,
		/// <summary>
		/// Composite value that sets both <see cref="GlibcCorrect"/> and <see cref="PosixCorrect"/>
		/// </summary>
		Strict = ( GlibcCorrect | PosixCorrect ),
		/// <summary>
		/// Throw an <see cref="System.ApplicationException"/> when a parsing error occurs.
		/// </summary>
		ThrowOnError = 0x04,
		/// <summary>
		/// Print an error message to <see cref="Console.Out"/> when a parsing error occurs.
		/// </summary>
		PrintOnError = 0x08
	}

	/// <summary>
	/// Provides an implementation of the getopt functions.
	/// </summary>
	/// <remarks>
	/// All state information that is maintained by any of the getopt methods is thread-static,
	/// meaning that it is particular to that thread of execution. Calling any of the methods
	/// of this class in separate threads will not conflict with each other.
	/// </remarks>
	public static class GetOpt
	{
		[ThreadStatic]
		private static object _target;
		[ThreadStatic]
		private static string _item;
		[ThreadStatic]
		private static string _text;
		[ThreadStatic]
		private static int _argsN;
		[ThreadStatic]
		private static int _textN;
		[ThreadStatic]
		private static int _charN;
		[ThreadStatic]
		private static bool _completed;
		[ThreadStatic]
		private static bool _corrected;

		/// <summary>
		/// Gets the name of the current option.
		/// </summary>
		/// <remarks>
		/// If <see cref="GetOptionsSettings.GlibcCorrect"/> or <see cref="GetOptionsSettings.PosixCorrect"/>
		/// are given as settings during parsing then this property will be null unless te current option has
		/// caused an error.
		/// </remarks>
		public static string Item {
			get { return _item; }
		}

		/// <summary>
		/// Gets the argument associated with the current argument, or returns null if no argument was found.
		/// </summary>
		public static string Text {
			get { return _text; }
		}

		/// <summary>
		/// Gets the index within the source array where normal non-option parsing should start.
		/// </summary>
		public static int Index {
			get { return _argsN; }
		}

		/// <summary>
		/// Resets the internal state of the parser.
		/// </summary>
		public static void Reset ( ) {
			Reset(null);
		}

		private static void Reset ( object target ) {
			// Reset all state variables.
			_target = target;
			_argsN = _textN = 0;
			_charN = 1;
			_item = _text = null;
			_completed = false;
			_corrected = false;
		}

		/// <summary>
		/// Gets the next option from the argument list.
		/// </summary>
		/// <param name="args">An array containing the program arguments.</param>
		/// <param name="options">
		/// A string that specifies the option characters that are valid for this program.
		/// An option character in this string can be followed by a colon (`:') to indicate
		/// that it takes a required argument. If an option character is followed by two
		/// colons (`::'), its argument is optional
		/// </param>
		/// <returns>The character representing the next option found, or -1 if the end of parsing is reached.</returns>
		public static int GetOptions ( string [ ] args, string options ) {
			return GetOptions(args, options, GetOptionsSettings.None);
		}
		/// <summary>
		/// Gets the next option from the argument list.
		/// </summary>
		/// <param name="args">An array containing the program arguments.</param>
		/// <param name="options">
		/// A string that specifies the option characters that are valid for this program.
		/// An option character in this string can be followed by a colon (`:') to indicate
		/// that it takes a required argument. If an option character is followed by two
		/// colons (`::'), its argument is optional
		/// </param>
		/// <param name="settings">A bitwise OR combination of <see cref="GetOptionsSettings"/> enumeration values.</param>
		/// <returns>The character representing the next option found, or -1 if the end of parsing is reached.</returns>
		public static int GetOptions ( string [ ] args, string options, GetOptionsSettings settings ) {
			if ( args == null )
				throw new ArgumentNullException("args");

			if ( ( options == null ) || ( options.Length < 1 ) )
				throw new ArgumentNullException("options");

			// This clause prevents operation on zero length arrays
			if ( args.Length > 0 ) {
				// Detect which flags are set
				bool glibcCorrect = ( ( settings & GetOptionsSettings.GlibcCorrect ) == GetOptionsSettings.GlibcCorrect );
				bool posixCorrect = ( ( settings & GetOptionsSettings.PosixCorrect ) == GetOptionsSettings.PosixCorrect );
				bool throwOnError = ( ( settings & GetOptionsSettings.ThrowOnError ) == GetOptionsSettings.ThrowOnError );
				bool printOnError = ( ( settings & GetOptionsSettings.PrintOnError ) == GetOptionsSettings.PrintOnError );

				// If this is not a consecutive call, then reset all state variables.
				if ( !object.ReferenceEquals(_target, args) || _completed )
					Reset(args);

				// Changed (@2008-05-29 21:38): Permutation of the 'args' array is now the default behavior.
				if ( !_corrected && !posixCorrect && ( options [ 0 ] != '+' ) ) {
					// The default implementation of glibc's getopt permutes the array being parsed
					// so that all non-option arguments are at the end in their respective order. This allows
					// programs to accept optional arguments even if they were not expecting them.

					// A temporary array to hold the result of the permutation is created.
					string [ ] tmp = new string [ args.Length ];
					int tmp_i = 0, tmp_j = ( -1 ), tmp_k = ( -1 ), tmp_n = 0;

					// Iterate through the array and pick out all option and their possible 
					// arguments and add them to the result array in the order they are detected.
					for ( tmp_i = 0 ; tmp_i < args.Length ; tmp_i++ ) {
						if ( ( args [ tmp_i ] != null ) && ( args [ tmp_i ].Length > 1 ) && ( args [ tmp_i ] [ 0 ] == '-' ) ) {
							tmp [ tmp_n++ ] = args [ tmp_i ];

							for ( tmp_j = 1 ; tmp_j < args [ tmp_i ].Length ; tmp_j++ ) {
								if ( ( tmp_k = options.IndexOf(args [ tmp_i ] [ tmp_j ]) ) != ( -1 ) ) {
									if ( ( ( tmp_k + 1 ) < options.Length ) && ( options [ tmp_k + 1 ] == ':' ) ) {
										// If the option argument is supplied with the option itself then continue
										// iteration through the array.
										if ( ( tmp_j < 2 ) && ( args [ tmp_i ].Length > 2 ) ) {
											if ( ( ( tmp_j + 1 ) < args [ tmp_i ].Length ) && ( options.IndexOf(args [ tmp_i ] [ tmp_j + 1 ]) < 0 ) )
												continue;
										}

										// If this option had an argument add it in succession to the 'result' array.
										if ( ( tmp_i + 1 ) < args.Length )
											tmp [ tmp_n++ ] = args [ ++tmp_i ];
									}
								}
							}
						}
					}

					// Iterate through the array and pick out all non-option arguments and add them
					// to the result array in the order they are detected.
					for ( tmp_i = 0 ; tmp_i < args.Length ; tmp_i++ ) {
						if ( ( args [ tmp_i ] != null ) && ( args [ tmp_i ].Length > 1 ) && ( args [ tmp_i ] [ 0 ] == '-' ) ) {
							for ( tmp_j = 1 ; tmp_j < args [ tmp_i ].Length ; tmp_j++ ) {
								if ( ( tmp_k = options.IndexOf(args [ tmp_i ] [ tmp_j ]) ) != ( -1 ) ) {
									if ( ( ( tmp_k + 1 ) < options.Length ) && ( options [ tmp_k + 1 ] == ':' ) ) {
										// If the option argument is supplied with the option itself then continue
										// iteration through the array.
										if ( ( tmp_j < 2 ) && ( args [ tmp_i ].Length > 2 ) ) {
											if ( ( ( tmp_j + 1 ) < args [ tmp_i ].Length ) && ( options.IndexOf(args [ tmp_i ] [ tmp_j + 1 ]) < 0 ) )
												continue;
										}

										// If this option had an argument, then it has already been stored in the 'result' array
										// so pass over it.
										if ( ( tmp_i + 1 ) < args.Length )
											++tmp_i;
									}
								}
							}
						} else {
							tmp [ tmp_n++ ] = args [ tmp_i ];
						}
					}

					// Overwrite the contents of 'array' with 'result'.
					Array.Copy(tmp, 0, args, 0, args.Length);

					// Set _corrected to true so that this process does not reoccur for this array.
					_corrected = true;
				}

				// Begin parsing by iteration over the array.
				// Any exit or conclusion from this loop breaks parsing and
				// causes the reset of all state variables.
				for ( int tmp_itr = ( -1 ) ; _argsN < args.Length ; ) {
					// Throw an exception if any element in the 'args' array is null.
					if ( args [ _argsN ] == null )
						throw new ArgumentNullException("args[" + _argsN + "]");

					// Reset these state variables to null so that their values are not
					// confused with the values set by a previous call.
					_item = null;
					_text = null;

					if ( ( args [ _argsN ].Length < 2 ) || ( args [ _argsN ] [ 0 ] != '-' ) ) {
						// POSIX demands that option parsing stop at the first non-option argument
						// however, if complete POSIX compliance is not specified, GetOptions will
						// will iterate over the array and parse all options it finds.
						if ( !_corrected && !posixCorrect && ( options [ 0 ] != '+' ) ) {
							// Small loop that breaks when an option is encountered.
							for ( tmp_itr = ( _argsN + 1 ) ; ( tmp_itr < args.Length ) && ( ( args [ tmp_itr ] == null ) || ( args [ tmp_itr ].Length < 2 ) || ( args [ tmp_itr ] [ 0 ] != '-' ) ) ; tmp_itr++ ) ;

							// Reset state variables so that iteration can continue;
							if ( tmp_itr < args.Length ) {
								_argsN = _textN = tmp_itr;
								_charN = 1;
								continue;
							}
						}

						// If no more options could be encountered (for any reason) iteration ends
						// and so does parsing.
						break;
					} else {
						// If "--" is encountered all option parsing must end.
						if ( args [ _argsN ] [ 1 ] == '-' ) {
							++_argsN;
							break;
						}

						for ( ; _charN < args [ _argsN ].Length ; ) {
							// Save the current option name.
							char c = args [ _argsN ] [ _charN ];

							// If no compliance flags are set, then set the _item state variable
							// to the current option name.
							if ( !glibcCorrect && !posixCorrect )
								_item = c.ToString();

							if ( ( tmp_itr = options.IndexOf(args [ _argsN ] [ _charN ]) ) != ( -1 ) ) {
								// Both glibc and POSIX have the _item counterpart 'optopt' unset when the option does not cause an error.
								if ( glibcCorrect || posixCorrect )
									_item = null;

								// If the current option is specified to have an argument...
								if ( ( ( tmp_itr + 1 ) < options.Length ) && ( options [ tmp_itr + 1 ] == ':' ) ) {
									// Detect if the argument is given with the option (i.e. "-cfoo") by examining the option string
									// and the character immediately following the option name. If it is not a valid optioon, then interpret
									// it and the following characters as the option argument.
									if ( ( _charN < 2 ) && ( args [ _argsN ].Length > 2 ) ) {
										if ( ( ( _charN + 1 ) < args [ _argsN ].Length ) && ( options.IndexOf(args [ _argsN ] [ _charN + 1 ]) < 0 ) ) {
											_text = args [ _argsN++ ].Remove(0, 2);
											_charN = 1;
											return ( ( int ) c );
										}
									}

									if ( ( ( _textN + 1 ) < args.Length ) && ( args [ ( _textN + 1 ) ] != "--" ) ) {
										_text = args [ ++_textN ];
									} else if ( ( ( tmp_itr + 2 ) >= options.Length ) || ( options [ ( tmp_itr + 2 ) ] != ':' ) ) {
										// If this option is missing its argument then perform standard error setting procedures.
										if ( glibcCorrect || posixCorrect )
											_item = c.ToString();

										if ( throwOnError )
											throw new ApplicationException("Option '" + c + "' requires an argument.");
										else if ( printOnError )
											Console.WriteLine("Option '{0}' requires an argument.", c);

										++_charN;
										return ( ( int ) '?' );
									}
								}

								++_charN;
								return ( ( int ) c );
							} else {
								// If this option is missing its argument then perform standard error setting procedures.
								if ( glibcCorrect || posixCorrect )
									_item = c.ToString();

								if ( throwOnError )
									throw new ApplicationException("Unknown option '" + c + "'.");
								else if ( printOnError )
									Console.WriteLine("Unknown option '{0}'.", c);

								++_charN;
								return ( ( int ) '?' );
							}
						}

						// If the option had an argument skip over it.
						if ( _textN > _argsN++ )
							_argsN = ++_textN;

						_textN = _argsN;
						_charN = 1;
					}
				}
			}

			// Flag parsing as completed and exit parsing.
			_completed = true;
			return ( -1 );
		}
	}
}
