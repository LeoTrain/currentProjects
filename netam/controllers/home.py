from models.main import Model
from views.main import View

class HomeController:
    def __init__(self, model: Model, view: View):
        self.model = model
        self.view = view
        self.frame = self.view.frames["home"]
        self._bind()
        
    def _bind(self):
        self.frame.logout_btn.configure(command=self.logout)
        self.frame.download_btn.configure(command=self.download)

    def download(self):
        self.view.switch("download")

    def logout(self):
        self.model.auth.logout()

    def update_view(self):
        if self.model.auth.current_user:
            self.frame.username_label.configure(text=f"Welcome, {self.model.auth.current_user.username}!")
        else:
            self.frame.username_label.configure(text=f"Errooooor")
