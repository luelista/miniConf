using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace miniConf {

    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    public class cls_globPara {

        //: ========== Globale Variablen ==========================================

        //string m_paraFileSpec;
        Dictionary<string, string> m_content = new Dictionary<string, string>();
        SqlDatabase db;

        const string tabDelimiter = "<=" + Constants.vbTab;


        //: ========== Konstruktor + Destruktor ==================================

        public cls_globPara(SqlDatabase database) {
            this.db = database;
            this.readFromDatabase();
        }



        //: ========== Haupteigenschaft ========================

        public string para(string key) {
            return para(key, "");
        }
        public string para(string key, string defaultValue) {
            string result = defaultValue;
            m_content.TryGetValue(key, out result);
            return result;
        }

        public void setPara(string key, string value) {
            this.db.ExecSQL("INSERT OR REPLACE INTO params (item, value) VALUES (?, ?)",
                key, value);
        }



        //: ========== Hilfsfunktionen ========================

        public string appPath() {
            return fp(Path.GetDirectoryName(Application.ExecutablePath));
        }
        public string fp(string path, string fileName = "") {
            return path + (path.EndsWith("\\") ? "" : "\\") + (fileName.StartsWith("\\") ? fileName.Substring(1) : fileName);
        }

        public string fpUNIX(string path, string fileName = "") {
            return path + (path.EndsWith("/") ? "" : "/") + (fileName.StartsWith("/") ? fileName.Substring(1) : fileName);
        }


        public bool Contains(string key) {
            return m_content.ContainsKey(key);

        }



        //: ========== Form-Tools ========================

        public void readFormPos(Form frm, bool readSize = true, string suffix = "") {
            try {
                string paraName = frm.Name.ToLower() + "__" + "Rect" + suffix;
                string[] formPos = Strings.Split(this.para(paraName), ";");
                frm.Left = Convert.ToInt32(formPos[0]);
                frm.Top = Convert.ToInt32(formPos[1]);
                if (readSize) {
                    frm.Width = Convert.ToInt32(formPos[2]);
                    frm.Height = Convert.ToInt32(formPos[3]);
                }


            } catch (Exception ex) {
            }
        }

        public void saveFormPos(Form frm, string suffix = "") {
            string formPos = null;

            var _with1 = frm;
            if (_with1.WindowState == FormWindowState.Minimized)
                _with1.WindowState = FormWindowState.Normal;
            formPos = _with1.Left.ToString() + ";" + _with1.Top.ToString() + ";" + _with1.Width.ToString() + ";" + _with1.Height.ToString();
            string paraName = frm.Name.ToLower() + "__" + "Rect" + suffix;
            this.setPara(paraName, formPos);
        }

        public void readTuttiFrutti(ContainerControl frm) {
            recursive_readTuttiFrutti(frm, frm);
        }
        public void saveTuttiFrutti(ContainerControl frm) {
            recursive_saveTuttiFrutti(frm, frm);
        }

        public void recursive_readTuttiFrutti(ContainerControl frm, Control ctrl) {
            // ERROR: Not supported in C#: OnErrorStatement

            string typ = null;
            string prefix = frm.Name + "__";
            foreach (Control subctrl in ctrl.Controls) {
                if (subctrl.Controls.Count > 0)
                    recursive_readTuttiFrutti(frm, subctrl);
                typ = subctrl.GetType().ToString();

                Debug.Print(subctrl.Name + Constants.vbTab + typ);
                if (subctrl.Name.StartsWith("qq_"))
                    continue;

                if (typ == "System.Windows.Forms.RadioButton") {
                    string[] paras = Strings.Split(subctrl.Name, "__");
                    if (this.para(prefix + paras[0]) == paras[1]) {
                        ((RadioButton)subctrl).Checked = true;
                    } else {
                        ((RadioButton)subctrl).Checked = false;
                    }
                }

                if (!this.Contains(prefix + subctrl.Name))
                    continue;
                Debug.Print("ja" + Constants.vbTab + subctrl.Name + Constants.vbTab + typ);

                if (typ == "System.Windows.Forms.TextBox") {
                    subctrl.Text = this.para(prefix + subctrl.Name);
                }
                if (typ == "System.Windows.Forms.ComboBox") {
                    subctrl.Text = this.para(prefix + subctrl.Name);
                }
                if (typ == "System.Windows.Forms.CheckBox") {
                    ((CheckBox)subctrl).Checked = (this.para(prefix + subctrl.Name) == "TRUE");
                }
                if (typ == "System.Windows.Forms.SplitContainer") {
                    ((SplitContainer)subctrl).SplitterDistance = Convert.ToInt32(this.para(prefix + subctrl.Name));
                    ((SplitContainer)subctrl).Orientation = (Orientation)Convert.ToInt32(this.para(prefix + subctrl.Name + ".Or"));
                }
                /*if (typ == "AxCCRPFolderTV6.AxFolderTreeview")
                {
                    subctrl.SelectedFolder.name = this.para(prefix + subctrl.Name);
                }*/
            }
        }
        public void recursive_saveTuttiFrutti(ContainerControl frm, Control ctrl) {
            // ERROR: Not supported in C#: OnErrorStatement

            string typ = null;
            string prefix = frm.Name + "__";
            foreach (Control subctrl in ctrl.Controls) {
                if (subctrl.Name.StartsWith("qq_"))
                    continue;
                typ = subctrl.GetType().ToString();

                if (typ == "System.Windows.Forms.TextBox") {
                    this.setPara(prefix + subctrl.Name, ((TextBox)subctrl).Text);
                }
                if (typ == "System.Windows.Forms.ComboBox") {
                    this.setPara(prefix + subctrl.Name, ((ComboBox)subctrl).Text);
                }
                if (typ == "System.Windows.Forms.CheckBox") {
                    this.setPara(prefix + subctrl.Name, (((CheckBox)subctrl).Checked ? "TRUE" : "FALSE"));
                }
                if (typ == "System.Windows.Forms.SplitContainer") {
                    this.setPara(prefix + subctrl.Name, ((SplitContainer)subctrl).SplitterDistance.ToString());
                    this.setPara(prefix + subctrl.Name + ".Or", Convert.ToInt32(((SplitContainer)subctrl).Orientation).ToString());
                }
                if (typ == "System.Windows.Forms.RadioButton") {
                    RadioButton radioBox = (RadioButton)subctrl;
                    if (radioBox.Checked) {
                        string[] paras = Strings.Split(subctrl.Name, "__");
                        this.setPara(prefix + paras[0], paras[1]);
                    }
                }
                /*if (typ == "AxCCRPFolderTV6.AxFolderTreeview")
                {
                    this.setPara(prefix + subctrl.Name, ((object)subctrl).SelectedFolder.name;
                }*/

                if (subctrl.Controls.Count > 0)
                    recursive_saveTuttiFrutti(frm, subctrl);
            }
        }


        //: ========== Private Funktionen ====================

        public void readFromDatabase() {
            var cmd = this.db.BuildCommand("SELECT item,value FROM params", new object[0]);
            var reader = cmd.ExecuteReader();
            foreach (System.Data.Common.DbDataRecord k in reader) {
                m_content[k.GetString(0)] = k.IsDBNull(1) ? "" : k.GetString(1);
            }
        }

        public void legacyImport(string m_paraFileSpec) {
            if (!File.Exists(m_paraFileSpec))
                return;

            try {
                string[] cont = Strings.Split(File.ReadAllText(m_paraFileSpec), Constants.vbNewLine);

                string[] line = null;
                foreach (string lineString in cont) {
                    line = Strings.Split(lineString, tabDelimiter);
                    if (line.Length < 2)
                        continue;

                    this.db.ExecSQL("INSERT OR IGNORE INTO params (item,value) VALUES (?,?)",
                        line[0], Strings.Replace(line[1], "|-ZS-|", Constants.vbNewLine));
                    //m_content.Add(line[0], Strings.Replace(line[1], "|-ZS-|", Constants.vbNewLine));
                    //TT.Write("ParaRead", line(0))
                    //Debug.Print(lineString)
                    //Stop
                }

            } catch (Exception e) {
                Interaction.MsgBox("beim Laden der Einstellungen ist ein Fehler aufgetreten:" + Constants.vbNewLine + e.Message + Constants.vbNewLine + "(cls_globPara)");
            }

            readFromDatabase();

        }




    }


}
