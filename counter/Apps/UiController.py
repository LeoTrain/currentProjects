from customtkinter import *
import customtkinter
from MessageBoxes.MessageBoxYesNo import MessageBoxYesNo
from MessageBoxes.MessageBoxAsk import MessageBoxAsk
from MessageBoxes.MessageBoxError import MessageBoxError
from MessageBoxes.MessageBoxItems import MessageBoxItems
from SaveLoadManager import SaveLoadManager
from Helpers.Save import Save

class UiController:
    def __init__(self, root: CTk, save: Save):
        self.root = root
        self.save = save
        self.labels = []
        self.save_file_path = "saves.sv"
        self.save_manager = SaveLoadManager(self.save_file_path)

    def add_labels(self, labels: list[dict[str, CTkLabel]]):
        for label in labels:
            self.labels.append(label)

    def save_button_click(self):
        try:
            saves = self.save_manager.load()
            save_already_exists = False
            for save in saves:
                if isinstance(save, dict) and "name" in save and "count" in save:
                    if save["name"] == self.save.name:
                        save["count"] = self.save.count
                        save["increment"] = self.save.count_increment
                        save_already_exists = True
                        break
            if not save_already_exists:
                saves.append({"name": self.save.name, "count": self.save.count, "increment": self.save.count_increment})

            self.save_manager.save(saves)
            MessageBoxError(self.root, "Save Successfull", f"We landed de spaceship.")
        except Exception:
            MessageBoxError(self.root, "Save Error", "We have an error captain.")

    def load_button_click(self, from_startup: bool=False):
        if not from_startup:
            self._ask_for_save_name()
        try:
            saves = self.save_manager.load()

            if not saves:
                MessageBoxError(self.root, "Load Error", "No saves found.")
                self.current_count = 0
                return

            for save in saves:
                if isinstance(save, dict) and "name" in save and "count" in save:
                    if save["name"] == self.save.name:
                        self.save.count = save["count"]
                        try:
                            self.save.count_increment = save["increment"]
                        except Exception:
                            self.save.count_increment = 1
                        self._update_labels()
                        return

            MessageBoxError(self.root, "Load Error", f"No save found with {self.save.name}")
            self._update_labels()
        except Exception:
             MessageBoxError(self.root, "Load Error", "We have an error captain.")

    def increment_button_click(self):
        self.save.increment()
        self._update_labels()

    def _ask_to_save_settings(self):
        message_box = MessageBoxYesNo(self.root, "Save Settings", "Do you want to apply the settings ?", self._handle_save_settings_response)
        self.root.wait_window(message_box.window)

    def _handle_save_settings_response(self, response):
        if isinstance(response, bool):
            if response:
                try:
                    for dict_item in self.labels:
                        if dict_item.get("name") == "setting_increment_size_input":
                            self.save.count_increment = int(dict_item["label"].get())
                    self.save_button_click()
                except Exception as e:
                    print(f"Error Saving Settings: {e}")

    def _ask_to_load_data(self):
        # message_box = MessageBoxYesNo(self.root, "Startup", "Do you want to load data", self._handle_to_load_data_response)
        saves = self.save_manager.load()
        options = []
        for save in saves:
            if isinstance(save, dict) and "name" in save and "count" in save:
                options.append(save["name"]) 
        message_box = MessageBoxItems(self.root, "Startup", "Choose save to load:", self._handle_to_load_data_response, options) 
        self.root.wait_window(message_box.window)

    def _handle_to_load_data_response(self, response):
        if isinstance(response, str):
            if response != "":
                self.save.name = response
                self.load_button_click(from_startup=True)

    def _ask_for_save_name(self):
        message_box = MessageBoxAsk(self.root, "What Name", "Gimme the save name: ", self._handle_save_name_response)
        self.root.wait_window(message_box.window)

    def _handle_save_name_response(self, response):
        if isinstance(response, str):
            self.save.name = response
            self._update_labels()

    def _update_settings_tab(self, input_label=None):
        if input_label:
            label = input_label
            if label.get("name") == "setting_increment_size_input":
                label["label"].configure(placeholder_text=f"{self.save.count_increment}")
        else:
            for label in self.labels:
                if label.get("name") == "setting_increment_size_input":
                    label["label"].configure(placeholder_text=f"{self.save.count_increment}")

    def _update_labels(self):
        for label in self.labels:
            if label.get("name") == "current_save_label":
                label["label"].configure(text=f"{self.save.name}")

            if label.get("name") == "current_count_label":
                label["label"].configure(text=f"{self.save.count}")

            self._update_settings_tab(label)

    def _on_tab_command(self):
        self._update_settings_tab()

    def _color_mode_switch(self):
        print(customtkinter.get_appearance_mode())
        if customtkinter.get_appearance_mode() == "Dark":
            customtkinter.set_appearance_mode("Light")
        else:
            customtkinter.set_appearance_mode("Dark")
