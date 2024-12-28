from customtkinter import CTkFrame, CTkLabel, CTkEntry, CTkButton, CTkProgressBar

class DownloadView(CTkFrame):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)

        self.title_label = CTkLabel(self, text="Download a YouTube Video", font=("Arial", 30, "bold"))
        self.title_label.place(relx=0.5, rely=0.05, anchor="center")

        self.instruction_label = CTkLabel(self, text="Insert the YouTube link below", font=("Arial", 16))
        self.instruction_label.place(relx=0.5, rely=0.13, anchor="center")

        self.link_entry = CTkEntry(self, placeholder_text="Paste YouTube link here", width=400, font=("Arial", 14))
        self.link_entry.place(relx=0.5, rely=0.25, anchor="center")

        self.preview_label = CTkLabel(self, text="No preview available", font=("Arial", 14), width=400, height=200)
        self.preview_label.place(relx=0.5, rely=0.5, anchor="center")

        self.progress_bar = CTkProgressBar(self, height=300, orientation='vertical')
        self.progress_bar.place(relx=0.8, rely=0.2)
        self.progress_bar.set(0)
        self.download_btn = CTkButton(self, text="Download", width=200, state="disabled")
        self.download_btn.place(relx=0.5, rely=0.75, anchor="center")

        self.return_btn = CTkButton(self, text="Return to Menu", width=200)
        self.return_btn.place(relx=0.5, rely=0.85, anchor="center")
