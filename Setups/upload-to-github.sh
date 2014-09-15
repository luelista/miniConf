#!/bin/sh

die () {
	echo "$*" >&2
	exit 1
}

test -f "config.sh" || die "Create config.sh in this directory with:\nexport GITHUB_CREDS=username:passwd"
source config.sh

#test $# -ge 2 ||
#die "Usage: $0 <tag-name> <path>..."

tagname="v$1"
description="Version $1"

#shift


url=https://api.github.com/repos/max-weller/miniConf/releases
id="$(curl -u $GITHUB_CREDS -s $url |
	grep -B1 "\"tag_name\": \"$tagname\"" |
	sed -n 's/.*"id": *\([0-9]*\).*/\1/p')"
test -n "$id" || {
	out="$(curl -u $GITHUB_CREDS -s -XPOST -d '{"tag_name":"'"$tagname"'","name":"'"$description"'","target_commitish":"master"}' $url)" ||
	die "Error creating release: $out"
	id="$(echo "$out" |
		sed -n 's/.*"id": *\([0-9]*\).*/\1/p')"
	test -n "$id" ||
	die "Could not create release for tag $tagname: $out"
}

url=https://uploads.${url#https://api.}

#for path
#do
path=miniconf-$1.exe

	case "$path" in
	*.exe)
		contenttype=application/executable
		;;
	*.7z)
		contenttype=application/zip
		;;
	*)
		die "Unknown file type: $path"
		;;
	esac
	basename="$(basename "$path")"
	__ln=( $( ls -Lon "$path" ) )
	__size=${__ln[3]}	
	curl -i -u $GITHUB_CREDS -XPOST -H "Content-Type: $contenttype" -H "Content-Length: ${__size}" \
		--data-binary @"$path" "$url/$id/assets?name=$basename"
#done