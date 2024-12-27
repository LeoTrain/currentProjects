import customtkinter
from views.root import Root
from views.signin import SignInView
from views.signup import SignUpView
from views.home import HomeView
from views.download import DownloadView

class View:
    def __init__(self):
        self.root = Root()
        customtkinter.set_default_color_theme("Styles/Cherry.json")
        customtkinter.set_appearance_mode("System")

        self.frames = {}
        
        self._add_frame(SignInView, "signin")
        self._add_frame(SignUpView, "signup")
        self._add_frame(HomeView, "home")
        self._add_frame(DownloadView, "download")

    def _add_frame(self, Frame, name):
        self.frames[name] = Frame(self.root)
        self.frames[name].grid(row=0, column=0, sticky="nsew")

    def switch(self, name):
        frame = self.frames[name]
        frame.tkraise()

    def start_mainloop(self):
        self.root.mainloop()
