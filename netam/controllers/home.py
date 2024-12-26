class HomeController:
    def __init__(self, model, view):
        self.model = model
        self.view = view
        self.frame = self.view.frames["home"]
        self._bind()
        
    def _bind(self):
        self.frame.logout_btn.configure(command=self.logout)

    def logout(self):
        self.model.auth.logout()

    def update_view(self):
        current_user = self.model.auth.current_user
        if current_user:
            self.frame.header.configure(text=f"Welcome, {current_user.username}!")
        else:
            self.frame.header.configure(text=f"")
