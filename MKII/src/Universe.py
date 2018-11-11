import Planet


class Universe(object):
    planets = []

    def level_one(self):
        earth = Planet.Planet((50,50),25)

        self.planets.append(earth)

    def draw(self, surface):
        for planet in self.planets:
            planet.draw(surface)