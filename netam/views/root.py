from customtkinter import CTk

class Root(CTk):
    def __init__(self):
        super().__init__()

        start_width = 500
        min_width = 400
        start_height = 300
        min_height = 250

        self.geometry(f"{start_width}x{start_height}")
        self.minsize(width=min_width, height=min_height)
        self.title("TKinter CVM")
        self.grid_columnconfigure(0, weight=1)
        self.grid_rowconfigure(0, weight=1)
