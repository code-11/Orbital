import Planet
import LockedOrbitPlanet


class Universe(object):
    planets = []

    def level_one(self):
        earth = Planet.Planet((150,150),25)

        moon = LockedOrbitPlanet.LockedOrbitPlanet(earth, 5, 40, 1)
        moon2 = LockedOrbitPlanet.LockedOrbitPlanet(earth, 5, 50, .9)
        moon3 = LockedOrbitPlanet.LockedOrbitPlanet(earth, 5, 60, .8)
        moon4 = LockedOrbitPlanet.LockedOrbitPlanet(earth, 5, 70, .7)

        self.planets.append(earth)
        self.planets.append(moon)
        self.planets.append(moon2)
        self.planets.append(moon3)
        self.planets.append(moon4)

    def draw(self, surface):
        for planet in self.planets:
            planet.draw(surface)
