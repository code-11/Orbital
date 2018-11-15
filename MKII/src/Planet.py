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
        fudge = 1  # on all sides
        x = self.pos[0]-self.radius-fudge
        y = self.pos[1]-self.radius-fudge
        w = self.radius*2 + 2*fudge
        h = self.radius*2 + 2*fudge

        pygame.draw.rect(surface, pygame.Color(0, 0, 0), pygame.rect.Rect(x, y, w, h))
        pygame.draw.circle(surface, pygame.Color(0, 0, 255), int_pos, self.radius)
