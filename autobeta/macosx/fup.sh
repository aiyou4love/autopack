#!/bin/sh
mono ../autotool/autopack.exe -z ../xml/finish/zipcmd.xml ../xml/bundle.xml
mono ../autotool/autopack.exe -p ../xml/finish/printcmd.xml ../xml/bundle.xml
