from .collision_detector import CollisionDetector
from .collision_effect_handler import CollisionEffectHandler
from .collision_resolver import CollisionResolver
from typing import List
from ..entities.base_character import BaseCharacter
from ..entities.tile import Tile


class CollisionManager:
    def __init__(self):
        self.collision_detector = CollisionDetector()
        self.collision_resolver = CollisionResolver()
        self.collision_effect_handler = CollisionEffectHandler()

    def handle_collisions(self, entities:List[BaseCharacter], tiles:List[Tile]):
        for entity in entities:
            collided_tiles = self.collision_detector.detect_tile_collisions(entity, tiles)
            if collided_tiles:
                self.collision_resolver.resolve_tile_collision(entity, collided_tiles)
            else:
                if entity.can_move:
                    entity.can_move_up = True
                    entity.can_move_down = True
                    entity.can_move_left = True
                    entity.can_move_right = True

            for other_entity in entities:
                if entity != other_entity:
                    if self.collision_detector.detect_entity_collision(entity, other_entity):
                        self.collision_resolver.resolve_entity_collision(entity, other_entity)
                    elif other_entity.isPlayer:
                        entity.can_move = True
                        # self.collision_effect_handler.handle_entity_collision_effects(entity, other_entity)

    def handleSingleCollision(self, entity, entities, tiles):
        collided_tiles = self.collision_detector.detect_tile_collisions(entity, tiles)
        if collided_tiles:
            self.collision_resolver.resolve_tile_collision(entity, collided_tiles)
        else:
            entity.can_move_up = True
            entity.can_move_down = True
            entity.can_move_left = True
            entity.can_move_right = True

        for other_entity in entities:
            if entity != other_entity:
                if self.collision_detector.detect_entity_collision(entity, other_entity):
                    self.collision_resolver.resolve_entity_collision(entity, other_entity)
                elif other_entity.isPlayer:
                    entity.can_move = True

