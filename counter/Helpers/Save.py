from datetime import datetime

class Save:
    def __init__(self,
                 id: datetime = datetime.now(),
                 name: str = "",
                 count: int = 0,
                 count_increment: int = 1):
        self.id = id
        self.name = name
        self.count = count
        self.count_increment = count_increment

    def increment(self):
        self.count += self.count_increment

    def is_empty(self) -> bool:
        return self.name == ""
