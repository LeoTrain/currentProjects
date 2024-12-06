import pygame
from pygame.math import Vector2
from ..helpers.directions import Directions
from ..entities.base_character import BaseCharacter

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

    def resolve_entity_collision(self, entity1, entity2) -> None:
        # marge = 10
        # When Enemy collides with Player
        if entity1.isEnemy() and entity2.isPlayer():
            entity1.changeMoving(False)
            # entity1.try_attack(entity2)
        if entity2.isEnemy() and entity2.isEnemy():
            # overlap = entity1.position - entity2.position
            # collision_left = collision_right = collision_up = collision_down = False
            # if abs(overlap.x) > abs(overlap.y):
            #     if overlap.x > 0:
            #         entity1.position.x = entity2.position.x + entity1.rect.width
            #         collision_left = True
            #     else:
            #         entity1.position.x = entity2.position.x - entity1.rect.width
            #         collision_right = True
            # else:
            #     if overlap.y > 0:
            #         entity1.position.y = entity2.position.y + entity1.rect.height
            #         collision_up = True
            #     else:
            #         entity1.position.y = entity2.position.y - entity1.rect.height
            #         collision_down = True
            # entity1.can_move_left = not collision_left
            # entity1.can_move_right = not collision_right
            # entity1.can_move_up = not collision_up
            # entity1.can_move_down = not collision_down
            distance = entity1.position.distance_to(entity2.position)
            radius1 = entity1.rect.width / 2
            radius2 = entity2.rect.width / 2
            combined_radius = radius1 + radius2

            separation = entity2.position - entity1.position
            direction = separation.normalize()
            overlap = combined_radius - distance
            adjustment = direction * (overlap / 2)
            entity1.position -= adjustment
            entity2.position += adjustment



        # if (isinstance(entity1, Enemy)):


