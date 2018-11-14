import Planet
import math


class LockedOrbitPlanet(Planet.Planet):
    parent = None
    orbit_radius = 0
    orbit_speed = 0
    tick=0

    def __init__(self, parent, radius, orbit_radius, orbit_speed):
        super(LockedOrbitPlanet, self).__init__((parent.pos[0]+orbit_radius, parent.pos[1]), radius)
        self.parent = parent
        self.orbit_radius = orbit_radius
        self.orbit_speed = orbit_speed

    def draw(self, surface):
        x = self.orbit_radius*math.sin(self.tick*self.orbit_speed) + self.parent.pos[0]
        y = self.orbit_radius*math.cos(self.tick*self.orbit_speed) + self.parent.pos[1]
        self.pos = (x, y)
        self.tick += .0001
        super(LockedOrbitPlanet, self).draw(surface)



