import pygame
from pygame.math import Vector2
from ..helpers.directions import Directions

class CollisionResolver:
    def resolve_tile_collision(self, entity, tiles):
        collision_left = collision_right = collision_up = collision_down = False

        for tile in tiles:
            overlap = entity.position - tile.position

            if abs(overlap.x) > abs(overlap.y):
                if overlap.x > 0:
                    entity.position.x = tile.position.x + tile.rect.width
                    collision_left = True
                else:
                    entity.position.x = tile.position.x - entity.rect.width
                    collision_right = True
            else:
                if overlap.y > 0:
                    entity.position.y = tile.position.y + tile.rect.height
                    collision_up = True
                else:
                    entity.position.y = tile.position.y - entity.rect.height
                    collision_down = True
        entity.can_move_left = not collision_left
        entity.can_move_right = not collision_right
        entity.can_move_up = not collision_up
        entity.can_move_down = not collision_down

    def resolve_entity_collision(self, entity1, entity2):
        # marge = 10
        # When Enemy collides with Player
        if entity1.isEnemy() and entity2.isPlayer():
            entity1.changeMoving(False)
            entity1.try_attack(entity2)
            # overlap_x = entity1.rect.centerx - entity2.rect.centerx
            # overlap_y = entity1.rect.centery - entity2.rect.centery
            #
            # if abs(overlap_x) > abs(overlap_y):
            #     if overlap_x > 0:
            #         entity1.rect.left = entity2.rect.right - marge
            #     else:
            #         entity1.rect.right = entity2.rect.left + marge
            # else:
            #     if overlap_y > 0:
            #         entity1.rect.top = entity2.rect.bottom - marge
            #     else:
            #         entity1.rect.bottom = entity2.rect.top + marge
        # if (isinstance(entity1, Enemy)):


