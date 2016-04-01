#!/bin/sh
cd

ctga0[0]=Desktop/autobeta/apk/interscene/texture
ctga0[1]=Desktop/autobeta/apk/chapter001/texture
ctga0[2]=Desktop/autobeta/apk/chapter001/texture/terrain
ctga0[3]=Desktop/autobeta/apk/chapter001/texture/tilelight
ctga0[4]=Desktop/autobeta/apk/chapter003/texture
ctga0[5]=Desktop/autobeta/apk/chapter004/texture
ctga0[6]=Desktop/autobeta/apk/chapter005/texture

ctga2[0]=Desktop/autobeta/apk/chapter001/texture/tilelayer

cpng0[0]=Desktop/autobeta/apk/interscene/texture/
cpng0[1]=Desktop/autobeta/apk/interscene01/texture

cpng1[0]=Desktop/autobeta/apk/interscene/fulltexture

cpng2[0]=Desktop/autobeta/apk/interscene/hqtexture

for i in ${ctga0[@]}; do
	rm -rf Desktop/texture/pvr/*.*
	rm -rf Desktop/texture/pngTexture/*.*
	rm -rf Desktop/texture/tgaTexture/*.*
	mv -f $i/*.tga Desktop/texture/tgaTexture/
	./Desktop/texture/tga2pvr.sh
	mv -f Desktop/texture/pvr/*.pvr $i/
 done
for i in ${ctga2[@]}; do
	rm -rf Desktop/texture/pvr/*.*
	rm -rf Desktop/texture/pngTexture/*.*
	rm -rf Desktop/texture/tgaTexture/*.*
	mv -f $i/*.tga Desktop/texture/tgaTexture/
	./Desktop/texture/tga2pvr2.sh
	mv -f Desktop/texture/pvr/*.pvr $i/
 done
for i in ${cpng0[@]}; do
	rm -rf Desktop/texture/pvr/*.*
	rm -rf Desktop/texture/pngTexture/*.*
	rm -rf Desktop/texture/tgaTexture/*.*
	mv -f $i/*.png Desktop/texture/pngTexture/
	./Desktop/texture/png2pvr1.sh
	mv -f Desktop/texture/pvr/*.pvr $i/
 done
for i in ${cpng1[@]}; do
	rm -rf Desktop/texture/pvr/*.*
	rm -rf Desktop/texture/pngTexture/*.*
	rm -rf Desktop/texture/tgaTexture/*.*
	mv -f $i/*.png Desktop/texture/pngTexture/
	./Desktop/texture/png2pvr1.sh
	mv -f Desktop/texture/pvr/*.pvr $i/
 done
 for i in ${cpng2[@]}; do
	rm -rf Desktop/texture/pvr/*.*
	rm -rf Desktop/texture/pngTexture/*.*
	rm -rf Desktop/texture/tgaTexture/*.*
	mv -f $i/*.png Desktop/texture/pngTexture/
	./Desktop/texture/png2pvr2.sh
	mv -f Desktop/texture/pvr/*.pvr $i/
 done
