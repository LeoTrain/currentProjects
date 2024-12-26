from models.main import Model
from views.main import View
from controllers.main import Controller

def main():
    view = View()
    model = Model()
    controller = Controller(model, view)
    controller.start()


if __name__ == "__main__":
    main()

