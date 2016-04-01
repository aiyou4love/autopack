#!/bin/sh
security unlock-keychain -p listlist
betadir=Desktop/MobaBeta/beta/Moba_Phone_Game/Moba_Phone_Code
inhousedir=Desktop/MobaBeta/inhouse/Moba_Phone_Game/Moba_Phone_Code
svndir=Desktop/MobaBeta/res/bin
cd
svn up $betadir --username zhaoyh --password 123456
svn up $inhousedir --username zhaoyh --password 123456
svn up $svndir --username zhaoyh --password 123456
