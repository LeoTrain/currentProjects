import pygame

from ..entities.moving_tile import MovingTile
from ..logic.sprite_loader import SpriteLoader
from ..logic.animation_controller import AnimationController
from ..logic.event_dick import event_dick
from ..helpers.directions import Directions
from pygame.math import Vector2

class BaseCharacter(MovingTile):
    def __init__(self, display, sprite_sheet_path, set_position:Vector2):
        super().__init__(display, set_position)

        self.sprite_loader = SpriteLoader(sprite_sheet_path)
        self.animation_controller = AnimationController(self.sprite_loader, self)
        self.sprites = self.sprite_loader.load_character_sprites(self.number_of_frames, self.sprite_widths, self.sprite_heights)

        self.life_points = 0
        self.attack_power = 0
        self.attack_range = 0

        self.current_state = "idle"
        self.current_direction = Directions.DOWNRIGHT
        self.can_attack = True

    def try_attack(self) -> None:
        if self.can_attack:
            self.attack()

    def attack(self) -> None:
        self.current_state = "attack"

    def take_damage(self, damage):
        self.life_points -= damage
        if self.life_points <= 0:
            if self.isPlayer():
                event = pygame.event.Event(event_dick["player_dead"])
                pygame.event.post(event)
            elif self.isEnemy:
                event = pygame.event.Event(event_dick["enemy_dead"])
                pygame.event.post(event)

    def isEnemy(self) -> bool:
        return False

    def isPlayer(self) -> bool:
        return False
