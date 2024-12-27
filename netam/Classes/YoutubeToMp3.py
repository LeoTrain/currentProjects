import yt_dlp
from PIL import Image
from io import BytesIO
import requests

class YoutubeToMp3:
    def download(self, url: str):
        ydl_opts = {
            'format': 'best',
            'outtmpl': 'Downloads/Youtube/%(title)s.%(ext)s',
            'quiet': True
        }
        with yt_dlp.YoutubeDL(ydl_opts) as ydl:
            ydl.download([url])

    def thumbnail(self, url: str):
        ydl_opts = {
            'quiet': True,
            'dump_single_json': True,
        }
        with yt_dlp.YoutubeDL(ydl_opts) as ydl:
            result = ydl.extract_info(url, download=False)
            thumbnail_url = result.get('thumbnail', None)
            if thumbnail_url:
                response = requests.get(thumbnail_url)
                if response.status_code == 200:
                    pil_image = Image.open(BytesIO(response.content))
                    image = ImageTk.PhotoImage(pil_image)
                    return image
            raise Exception("Thumbnail not found.")
