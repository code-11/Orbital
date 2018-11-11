import pygame
import sys
from pygame.locals import *

from Universe import *


class Main(object):
    universe=None

    def run(self):
        self.universe = Universe()
        self.universe.level_one()

        self.pygame_main_loop()

    def pygame_main_loop(self):
        pygame.init()
        DISPLAYSURF = pygame.display.set_mode((400, 300))
        pygame.display.set_caption('Hello World!')
        while True:  # main game loop
            for event in pygame.event.get():
                if event.type == QUIT:
                    pygame.quit()
                    sys.exit()

            self.universe.draw(DISPLAYSURF)
            pygame.display.update()


if __name__ == "__main__":
    main = Main()
    main.run()
