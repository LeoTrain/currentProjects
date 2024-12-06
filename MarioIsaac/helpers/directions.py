from pygame.math import Vector2

class Directions:
    EMPTY = Vector2(0, 0)
    UP = Vector2(0, -1)
    DOWN = Vector2(0, 1)
    RIGHT = Vector2(1, 0)
    LEFT = Vector2(-1, 0)
    UPLEFT = UP + LEFT
    UPRIGHT = UP + RIGHT
    DOWNLEFT = DOWN + LEFT
    DOWNRIGHT = DOWN + RIGHT

    @classmethod
    def all_directions(cls):
        return [cls.EMPTY, cls.LEFT, cls.RIGHT, cls.UP, cls.DOWN, cls.UPLEFT, cls.UPRIGHT, cls.DOWNLEFT, cls.DOWNRIGHT]
