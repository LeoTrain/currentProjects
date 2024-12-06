import pygame
from typing import Tuple
from ..entities.base_character import BaseCharacter


class CollisionDetector:
    def detect_tile_collisions(self, entity, tiles):
        collided_tiles = []
        for tile in tiles:
            if pygame.sprite.collide_rect(entity, tile):
                collided_tiles.append(tile)
        return collided_tiles

    def detect_entity_collision(self, entity1:BaseCharacter, entity2:BaseCharacter) -> Tuple[int, int] | None:
        return pygame.sprite.collide_mask(entity1, entity2)
