from customtkinter import CTkFrame, CTkLabel, CTkButton

class HomeView(CTkFrame):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)

        self.header = CTkLabel(self, font=("Arial", 40, "bold"), text="Heluu")
        self.header.place(relx=0.5, rely=0.1, anchor="center")

        self.subheader = CTkLabel(self, font=("Arial", 20), text="this is a subheader")
        self.subheader.place(relx=0.5, rely=0.2, anchor="center")

        self.username_label = CTkLabel(self, font=("Arial", 18))
        self.username_label.place(relx=0.5, rely=0.3, anchor="center")

        self.download_btn = CTkButton(self, width=200, text="Download")
        self.download_btn.place(relx=0.5, rely=0.55, anchor="center")

        self.profile_btn = CTkButton(self, width=200, text="Check profile")
        self.profile_btn.place(relx=0.5, rely=0.65, anchor="center")

        self.settings_btn = CTkButton(self, width=200, text="Settings")
        self.settings_btn.place(relx=0.5, rely=0.75, anchor="center")

        self.logout_btn = CTkButton(self, width=200, text="Deconnect")
        self.logout_btn.place(relx=0.5, rely=0.85, anchor="center")

