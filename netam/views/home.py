from customtkinter import CTkFrame, CTkLabel, CTkEntry, CTkButton

class HomeView(CTkFrame):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)

        self.header = CTkLabel(self, font=("Arial", 40))
        self.header.place(relx=0.5, rely=0.1, anchor="center")

        self.logout_btn = CTkButton(self, text="Logout")
        self.logout_btn.place(relx=0.5, rely=0.8, anchor="center")
