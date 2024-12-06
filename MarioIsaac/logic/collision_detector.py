import pygame
from pygame.math import Vector2

class CollisionDetector:
    def detect_tile_collisions(self, entity, tiles):
        return [tile for tile in tiles if pygame.sprite.collide_rect(entity, tile)]

    def detect_entity_collision(self, entity1, entity2) -> Vector2 | None:
        offset = (int(entity2.position.x - entity1.position.x), int(entity2.position.y - entity1.position.y))
        collision_point = entity1.mask.overlap(entity2.mask, offset)
        if collision_point:
            return Vector2(collision_point[0] - entity1.rect.width // 2, collision_point[1] - entity1.rect.height // 2)
        return None

