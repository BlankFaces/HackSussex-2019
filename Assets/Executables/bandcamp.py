import requests
import time
import sys
import re
import os

url = sys.argv[1]

is_valid_url = re.findall(r'https:\/\/(.*)\.bandcamp\.com\/track\/(.*)', url)

if len(is_valid_url) is not 0:
    file_name = "%s_%s" % (is_valid_url[0][0], is_valid_url[0][1])
    file_path = "%s/%s.mp3" % (sys.argv[2], file_name)

    req = requests.get(url)
    
    if req.status_code == 200:
        raw = req.text
        urls = re.findall(r'{"mp3-128":"(.*)"}', raw)
        mp3_raw = requests.get(urls[0])

        req_code = re.findall(r'<head>\n?.*<title>([0-9]*).*<\/title>\n?.*<\/head>', mp3_raw.text)

        if len(req_code) == 0:
            mp3_file = open(file_path, 'wb')
            mp3_file.write(mp3_raw.content)

            while not os.path.exists(file_path):
                time.sleep(1)
                

            if os.path.isfile(file_path):
                sys.stdout.write(str(file_name)) # the filename
            else:
                sys.stdout.write(str(2)) # File deleted when made
        else:
            sys.stdout.write(str(3)) # Response which isn't 200
    else:
        sys.stdout.write(str(3)) # Response which isn't 200

else:
    sys.stdout.write(str(4)) # Invalid URL
