import sys
import os
import pygame

from settings import Settings
from ship import Ship
import game_functions as gf
from pygame.sprite import Group
from alien import Alien
from game_stats import GameStats
from button import Button
from scorecard import Scoreboard

def run_game():
    # Intialize game and create a screen object
    pygame.init()
    settings = Settings()
    screen = pygame.display.set_mode((settings.screen_width, settings.screen_height))
    pygame.display.set_caption("Alien Invasion")

    # Make the Play button.
    play_button = Button(settings, screen, "Play")
    
    # Create an instance to store game statistics.
    stats = GameStats(settings)
    ship = Ship(settings, screen)
    bullets = Group()
    aliens = Group()

    # Create an instance to store game statistics and create a scoreboard
    sb = Scoreboard(settings, screen, stats)
    

    # Create a fleet of aliens
    gf.create_fleet(settings, screen, ship, aliens)

    # Start the main loop for the game.
    while True:
        # Watch for keyboard and mouse events.
        gf.check_events(settings, screen, stats, sb, play_button, ship, aliens, bullets)
        
        if stats.game_active:
            ship.update()
            gf.update_bullets(settings, screen, stats, sb, ship, aliens, bullets)
            gf.update_aliens(settings, screen, stats, sb, ship, aliens, bullets)
        
        gf.update_screen(settings, screen, stats, sb, ship, aliens, bullets, play_button)

#print(os.getcwd())
run_game()