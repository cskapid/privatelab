import sys
import os
import pygame

from settings import Settings
from ship import Ship
import game_functions as gf
from pygame.sprite import Group
from alien import Alien

def run_game():
    # Intialize game and create a screen object
    pygame.init()
    settings = Settings()
    screen = pygame.display.set_mode((settings.screen_width, settings.screen_height))
    pygame.display.set_caption("Alien Invasion")
    ship = Ship(settings, screen)
    bullets = Group()
    aliens = Group()

    # Create a fleet of aliens
    gf.create_fleet(settings, screen, ship, aliens)

    # Start the main loop for the game.
    while True:
        # Watch for keyboard and mouse events.
        gf.check_events(settings, screen, ship, bullets)
        ship.update()
        gf.update_bullets(bullets)
        gf.update_screen(settings, screen, ship, aliens, bullets)

#print(os.getcwd())
run_game()