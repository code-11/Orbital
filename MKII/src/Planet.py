import pygame


class Planet (object):
    pos = (0, 0)
    radius = 0
    gravity = 5

    def __init__(self, pos, radius):
        self.pos = pos
        self.radius = radius

    def draw(self, surface):
        int_pos = (int(self.pos[0]), int(self.pos[1]))
        pygame.draw.circle(surface, pygame.Color(0, 0, 255), int_pos, self.radius)
