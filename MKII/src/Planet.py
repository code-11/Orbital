import pygame


class Planet (object):
    pos = (0, 0)
    radius = 0
    gravity = 5

    def __init__(self, pos, radius):
        self.pos = pos
        self.radius = radius

    def draw(self, surface):
        pygame.draw.circle(surface, pygame.Color(0, 0, 255), self.pos, self.radius)
