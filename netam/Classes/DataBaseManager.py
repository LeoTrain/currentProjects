from Classes.User import User
import sqlite3

class DataBaseManager:
    def __init__(self, file_path: str):
        self.file_path = file_path
        self.connection = sqlite3.connect(self.file_path)
        self.cursor = self.connection.cursor()
        self._init_tables()

    def _init_tables(self):
        survey = """
        CREATE TABLE IF NOT EXISTS Users (
                id INTEGER PRIMARY KEY UNIQUE,
                fullname TEXT NOT NULL,
                username TEXT NOT NULL UNIQUE,
                password TEXT NOT NULL
                )
        """
        self.cursor.execute(survey)
        self.connection.commit()

    def create_new_user(self, user: User) -> bool:
        column_values = {
                "fullname": user.fullname,
                "username": user.username,
                "password": user.password
                }
        try:
            return self._insert_into_table("Users", column_values)
        except sqlite3.IntegrityError as e:
            raise sqlite3.IntegrityError(f"Error while creating new user: {e}")

    def delete_user(self, user: User):
        condition = f"id={user.id}"
        self._delete_from_table("Users", condition)

    def get_all_users(self) -> list[User]:
        users = []
        rows = self._full_table("Users")
        for row in rows:
            user = User(row[0], row[1], row[2], row[3])
            users.append(user)
        return users

    def _insert_into_table(self, table_name: str, column_values: dict):
        columns = ", ".join(column_values.keys())
        placeholders = ", ".join(["?"] * len(column_values))
        values = tuple(column_values.values())

        query = f"INSERT INTO {table_name} ({columns}) VALUES ({placeholders})"
        try:
            self.cursor.execute(query, values)
            self.connection.commit()
            return True
        except sqlite3.IntegrityError as e:
            raise sqlite3.IntegrityError(f"Error while inserting into {table_name}: {e}")

    def _delete_from_table(self, table_name: str, condition: str):
        query = f"DELETE FROM {table_name} WHERE {condition}"
        try:
            self.cursor.execute(query)
        except Exception as e:
            print(f"ERROR as {e}")

    def _full_table(self, table_name: str):
        self.cursor.execute(f"SELECT * FROM {table_name}")
        return  self.cursor.fetchall()
