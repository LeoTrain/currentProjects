from models.main import Model
from views.main import View
from customtkinter import CTkImage
from PIL import Image
from io import BytesIO
import threading

class DownloadController:
    def __init__(self, model: Model, view: View):
        self.model = model
        self.view = view
        self.frame = self.view.frames["download"]
        self._bind()
        
    def _bind(self):
        self.frame.return_btn.configure(command=self.to_home)
        self.frame.link_entry.bind("<Return>", self._update_all)
        self.frame.download_btn.configure(command=self.download)

    def download(self, event=None):
        self.frame.download_btn.configure(state="disabled")
        self.frame.progress_bar.set(0)
        threading.Thread(target=lambda: self._download_video(self.frame.link_entry.get())).start()

    def _download_video(self, url: str):
        try:
            self.model.youtube.download(url, on_progress=self.update_progress)
            self.frame.download_btn.configure(state="normal")
            self.frame.title_label.configure(text="Download finished!")
        except Exception as e:
            print(f"Error downloading: {e}")
            self.frame.download_btn.configure(state="normal")

    def update_progress(self, stream, chunk, bytes_remaining):
        total_size = stream.filesize
        bytes_downloaded = total_size - bytes_remaining
        progress = bytes_downloaded / total_size * 10
        self.frame.progress_bar.set(progress)
        self.frame.link_entry.bind("<Return>", self.update_thumbnail)

    def to_home(self):
        self.view.switch("home")

    def _update_all(self, event=None):
        self._update_title()
        self.update_thumbnail()

    def _update_title(self):
        url = self.frame.link_entry.get()
        title = self.model.youtube.title(url)
        self.frame.title_label.configure(text=title)

    def update_thumbnail(self, event=None):
        try:
            thumbnail_path = self.model.youtube.thumbnail(self.frame.link_entry.get())
            if thumbnail_path:
                if isinstance(thumbnail_path, BytesIO):
                    image = CTkImage(Image.open(thumbnail_path), size=(350, 200))
                else:
                    image = CTkImage(Image.open(thumbnail_path), size=(350, 200))
                self.frame.preview_label.configure(image=image, text="") 
                self.frame.download_btn.configure(state='normal')
        except Exception as e:
            print(f"ERROR updating thumbnail: {e}")

    def fetch_thumbnail(self, youtube_link):
        try:
            image = self.model.youtube.thumbnail(youtube_link)
            self.update_preview_label(image)
        except Exception as e:
            self.update_preview_label(f"Error: {str(e)}")

    def update_preview_label(self, image):
        self.frame.preview_label.configure(image=image)


