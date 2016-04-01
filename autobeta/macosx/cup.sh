#!/bin/sh
cd

ctga0[0]=Desktop/autobeta/update/interscene/texture
ctga0[1]=Desktop/autobeta/update/chapter001/texture
ctga0[2]=Desktop/autobeta/update/chapter001/texture/terrain
ctga0[3]=Desktop/autobeta/update/chapter001/texture/tilelight
ctga0[4]=Desktop/autobeta/update/chapter003/texture
ctga0[5]=Desktop/autobeta/update/chapter004/texture
ctga0[6]=Desktop/autobeta/update/chapter005/texture

ctga2[0]=Desktop/autobeta/update/chapter001/texture/tilelayer

cpng0[0]=Desktop/autobeta/update/interscene/texture/
cpng0[1]=Desktop/autobeta/update/interscene01/texture

cpng1[0]=Desktop/autobeta/update/interscene/fulltexture

cpng2[0]=Desktop/autobeta/update/interscene/hqtexture

for i in ${ctga0[@]}; do
	rm -rf Desktop/texture/pvr/*.*
	rm -rf Desktop/texture/pngTexture/*.*
	rm -rf Desktop/texture/tgaTexture/*.*
	mv -f $i/*.png Desktop/texture/tgaTexture/
	./Desktop/texture/tga2pvr.sh
	mv -f Desktop/texture/pvr/*.pvr $i/
 done
for i in ${ctga2[@]}; do
	rm -rf Desktop/texture/pvr/*.*
	rm -rf Desktop/texture/pngTexture/*.*
	rm -rf Desktop/texture/tgaTexture/*.*
	mv -f $i/*.png Desktop/texture/tgaTexture/
	./Desktop/texture/tga2pvr2.sh
	mv -f Desktop/texture/pvr/*.pvr $i/
 done
for i in ${cpng0[@]}; do
	rm -rf Desktop/texture/pvr/*.*
	rm -rf Desktop/texture/pngTexture/*.*
	rm -rf Desktop/texture/tgaTexture/*.*
	mv -f $i/*.png Desktop/texture/pngTexture/
	./Desktop/texture/png2pvr.sh
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
