from pytubefix import YouTube, Stream
from urllib.parse import urlparse, parse_qs
import requests
import re
import os

class MyTube:
    def download(self, url: str, on_progress=None):
        output_path = "Downloads/YouTube/Videos/"
        try:
            print("before stream")
            stream = self._get_high_stream(url, on_progress)
            print("got stream")
            stream.download(output_path=output_path)
            if os.path.exists(f"{output_path}{stream.default_filename}"):
                raise Exception("File already downloaded")
                    
            print("downloaded")
        except Exception as e:
            raise Exception(f"Error downloading youtube video: {e}")

    def title(self, url: str):
        response = requests.get(url)
        if response.status_code == 200:
            match = re.search(r'<title>(.*?)</title>', response.text)
            if match:
                return match.group(1).replace(" - YouTube", "").replace("&quot;", "'").replace("&#39;", "'").strip()
        return "Unknown Title"

    def thumbnail(self, url: str, output_path: str = "Downloads/YouTube/"):
        try:
            video_id = parse_qs(urlparse(url).query).get("v", [None])[0]
            thumbnail_url = f"https://img.youtube.com/vi/{video_id}/maxresdefault.jpg"
            response = requests.get(thumbnail_url)
            
            if response.status_code == 200:
                os.makedirs(output_path, exist_ok=True)
                thumbnail_path = os.path.join(output_path, f"{video_id}_thumbnail.jpg")
                
                with open(thumbnail_path, "wb") as f:
                    f.write(response.content)
                
                return thumbnail_path
            else:
                return False
        except Exception as e:
            print(f"Error : {e}")

    def _get_high_stream(self, url: str, on_progress=None) -> Stream | None:
        if not on_progress:
            yt = YouTube(url)
        else:
            yt = YouTube(url, on_progress_callback=on_progress)
        return yt.streams.filter(progressive=True, file_extension='mp4').order_by('resolution').desc().first()
