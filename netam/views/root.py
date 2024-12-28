from customtkinter import CTk

class Root(CTk):
    def __init__(self):
        super().__init__()

        # start_width = 800
        # min_width = 800
        # max_width = 800
        # start_height = 500
        # min_height = 500
        # max_height = 500

        width = 800
        height = 500

        screen_width = self.winfo_screenwidth()
        screen_height = self.winfo_screenheight()

        x_position = (screen_width // 2) - (width // 2)
        y_position = (screen_height // 2) - (height // 2)

        self.geometry(f"{width}x{height}+{x_position}+{y_position}")
        self.minsize(width=width, height=height)
        self.maxsize(width=width, height=height)
        self.title("TKinter CVM")
        self.grid_columnconfigure(0, weight=1)
        self.grid_rowconfigure(0, weight=1)
