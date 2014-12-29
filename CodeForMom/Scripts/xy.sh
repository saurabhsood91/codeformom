rm -rf *.mp4
youtube-dl $1
ffmpeg -i *.mp4 $3
mv *.mp4 $2