#include <stdio.h>
#include <stdint.h>
#include <stdbool.h>
#include <SDL2/SDL.h>

SDL_Window* window = NULL;
SDL_Renderer* renderer = NULL;

//colour buffer array
uint32_t* color_buffer = NULL;

//Resolution of the window
int window_width = 1280;
int window_height = 720; 

bool is_running = false;

bool initialize_window(void){
        if (SDL_Init(SDL_INIT_EVERYTHING)!= 0){
                fprintf(stderr, "ERROR initializing SDL\n");
                return false;
        };

        window = SDL_CreateWindow(
                        "My First SDL Window", 
                        SDL_WINDOWPOS_CENTERED, 
                        SDL_WINDOWPOS_CENTERED,
                        window_width,
                        window_height,
                        SDL_WINDOW_BORDERLESS
                );
        if (!window){
                fprintf(stderr, "Error creating SDL Window\n");
                return false;
        }

        renderer = SDL_CreateRenderer(window, -1, 0);
        if(!renderer){
                fprintf(stderr, "Error creating SDL Renderer\n");
                return false;
        }

        return true;
}

bool setup(void){
        color_buffer = (uint32_t*)malloc(sizeof(uint32_t) * window_width * window_height);
        if(color_buffer == NULL){
                fprintf(stderr, "Cannot initialize the color buffer!\n");
                return false;
        }
        return true;
}

void process_input(void){
        SDL_Event event;
        SDL_PollEvent(&event);

        switch (event.type)
        {
                case SDL_QUIT:
                        is_running = false; 
                        break;
                case SDL_KEYDOWN:
                        if(event.key.keysym.sym == SDLK_ESCAPE)
                                is_running = false;
                default:
                        break;
        }
}

void update(void){

}

void render(void){
        SDL_SetRenderDrawColor(renderer, 0, 255, 255, 255);
        SDL_RenderClear(renderer);
        SDL_RenderPresent(renderer);
}

void clean_up(void){
        free(color_buffer);
        SDL_DestroyRenderer(renderer);
        SDL_DestroyWindow(window);
        SDL_Quit();
}

int main(void) {
        is_running = initialize_window();

        if(!setup()) return 0;

        while(is_running){
                process_input();
                update();
                render();
        };

        clean_up();


        return 0;
}