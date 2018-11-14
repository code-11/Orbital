import Planet
import LockedOrbitPlanet


class Universe(object):
    planets = []

    def level_one(self):
        earth = Planet.Planet((50,50),25)

        moon = LockedOrbitPlanet.LockedOrbitPlanet(earth, 5, 40, 1)

        self.planets.append(earth)
        self.planets.append(moon)

    def draw(self, surface):
        for planet in self.planets:
            planet.draw(surface)
