#!/bin/sh
./svnup.sh
mono autotool/autopack.exe -a xml/apk/update.xml xml/bundle.xml
mono autotool/autopack.exe -u xml/update/modify.xml xml/bundle.xml
./cup.sh
