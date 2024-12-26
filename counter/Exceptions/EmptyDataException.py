class EmptyDataException(Exception):
    def __init__(self, message="The data in the file is empty or invalid"):
        self.message = message
        super().__init__(self.message)
