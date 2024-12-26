from customtkinter import CTkFrame, CTkLabel, CTkButton, CTkEntry

class SignInView(CTkFrame):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.grid_columnconfigure(0, weight=1)
        self.grid_rowconfigure(1, weight=1)
        
        self.header = CTkLabel(self, text="Sign In with existing account", font=("Arial", 40))
        self.header.place(relx=0.5, rely=0.1, anchor="center")

        self.input_frame = CTkFrame(self, fg_color="#C6A6A5", width=400, height=250)
        self.input_frame.place(relx=0.5, rely=0.5, anchor="center")

        self.username_label = CTkLabel(self.input_frame, text="Username", font=("Arial", 24))
        self.username_input = CTkEntry(self.input_frame)
        self.username_label.place(relx=0.2, rely=0.4, anchor="center")
        self.username_input.place(relx=0.7, rely=0.4, anchor="center")

        self.password_label = CTkLabel(self.input_frame, text="Password", font=("Arial", 24))
        self.password_input = CTkEntry(self.input_frame, show="*")
        self.password_label.place(relx=0.2, rely=0.52, anchor="center")
        self.password_input.place(relx=0.7, rely=0.52, anchor="center")

        self.signin_btn = CTkButton(self, text="Sign In")
        self.signin_btn.grid(row=3, column=1, padx=0, pady=10, sticky="w")

        self.signup_option_label = CTkLabel(self, text="Don't have an account?")
        self.signup_btn = CTkButton(self, text="Sign Up")
        self.signup_option_label.grid(row=4, column=1, sticky="w")
        self.signup_btn.grid(row=5, column=1, sticky="w")
        
