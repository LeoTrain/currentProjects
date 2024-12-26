from Exceptions.EmptyDataException import EmptyDataException
import pickle
import os

class SaveLoadManager:
    def __init__(self, save_file_path) -> None:
        self.file_path = save_file_path


        if not os.path.exists(save_file_path):
            with open(save_file_path, "wb") as file:
                pickle.dump({}, file)

    def save(self, data: list[dict]) -> bool:
        try:
            with open(self.file_path, "wb") as file:
                pickle.dump(data, file)
                return True
        except Exception:
            return False

    def load(self) -> list[dict]:
        try:
            with open(self.file_path, "rb") as file:
               data = pickle.load(file)

            if isinstance(data, dict):
                data = [data]
            return data
        except EmptyDataException as e:
            return []
        except Exception:
            return []
