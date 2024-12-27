from models.main import Model
from views.main import View
import threading

class DownloadController:
    def __init__(self, model: Model, view: View):
        self.model = model
        self.view = view
        self.frame = self.view.frames["download"]
        self._bind()
        
    def _bind(self):
        self.frame.return_btn.configure(command=self.to_home)
        self.frame.link_entry.bind("<Return>", self.update_thumbnail)

    def to_home(self):
        self.view.switch("home")

    def update_thumbnail(self, event=None):
        youtube_link = self.frame.link_entry.get()
        thumbnail_thread = threading.Thread(target=self.fetch_thumbnail, args=(youtube_link,))
        thumbnail_thread.start()

    def fetch_thumbnail(self, youtube_link):
        try:
            image = self.model.youtube.thumbnail(youtube_link)
            self.update_preview_label(image)
        except Exception as e:
            self.update_preview_label(f"Error: {str(e)}")

    def update_preview_label(self, image):
        self.frame.preview_label.configure(image=image)


