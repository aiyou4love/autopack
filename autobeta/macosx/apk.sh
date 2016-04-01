#!/bin/sh
./svnup.sh
mono autotool/autopack.exe -a xml/apk/init.xml xml/bundle.xml
mono autotool/autopack.exe -u xml/update/build.xml xml/bundle.xml
./capk.sh
