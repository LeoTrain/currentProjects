from pygame.mixer_music import set_pos
from ..entities.tile import Tile
from ..helpers.directions import Directions
from pygame.math import Vector2


class MovingTile(Tile):
    def __init__(self, display, set_position:Vector2):
        super().__init__(display, set_position=set_position)
        self.speed = 0
        self.last_pressed_direction = "down"
        self.can_move_left = True
        self.can_move_right = True
        self.can_move_up = True
        self.can_move_down = True
        self.can_move = True

    def move(self, direction:Vector2=Directions.LEFT):
        if (self.can_move):
            self.update_old_rect()
            self.position = self.position + (direction * self.speed)
            self._update_rectangle()

    def isMoving(self):
        return self.can_move_left or self.can_move_right or self.can_move_up or self.can_move_left

    def changeMoving(self, can_move: bool):
        self.can_move_left = can_move
        self.can_move_right = can_move
        self.can_move_up = can_move
        self.can_move_down = can_move
        self.can_move = False
