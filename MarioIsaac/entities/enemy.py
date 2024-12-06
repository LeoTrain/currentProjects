import time
import math

from ..entities.base_character import BaseCharacter


class Enemy(BaseCharacter):
    def __init__(self, display, sprite_sheet):
        super().__init__(display, sprite_sheet)

    def _is_in_attack_range(self, player_pos):
        in_range = False
        if (
            abs(self.rect.x - player_pos[0]) <= self.attack_range
            and abs(self.rect.y - player_pos[1]) <= self.attack_range):
            in_range = True
        return in_range

    def move_to_player(self, player_pos):
        if self.can_move:
            if player_pos[0] < self.rect.x:
                x_direction = -1
                self.current_x_direction = "left"
            elif player_pos[0] > self.rect.x:
                x_direction = 1
                self.current_x_direction = "right"
            else:
                x_direction = 0

            if player_pos[1] < self.rect.y:
                y_direction = -1
                self.current_y_direction = "up"
            elif player_pos[1] > self.rect.y:
                y_direction = 1
                self.current_y_direction = "down"
            else:
                y_direction = 0

            self.move(x_direction, y_direction)
            self.current_state = "run"

    def try_attack(self, player):
        if self.can_attack(player):
            self.attack()
            player.take_damage(self.attack_power)

    def can_attack(self, player):
        can_attack = False
        time_passed = time.time() - self.attack_start_time
        if time_passed > 2 and self.isCloseEnough(player, 100):
            can_attack = True
        return can_attack

    def isCloseEnough(self, player, threshold):
        return math.sqrt((player.rect.centerx - self.rect.centerx)**2 + (player.rect.centery - self.rect.centery)**2) < threshold

    def attack(self) -> None:
        super().attack()
        self.attack_start_time = time.time()

    def isEnemy(self) -> bool:
        return True

    def updatePosition(self, player_pos):
        self.move_to_player(player_pos)

    def updateSprite(self):
        self.animation_controller.update_sprite()
