extends Node

const DEFAULT_IS_HEALTH_ON: bool = true
const DEFAULT_IS_TIMER_ON: bool = false
const DEFAULT_HEALTH_POINTS: int = 3
const DEFAULT_GAME_TIME: int = 60
const DEFAULT_PAIRS_COUNT: int = 8

var is_health_on: bool = DEFAULT_IS_HEALTH_ON
var is_timer_on: bool = DEFAULT_IS_TIMER_ON
var health_points: int = DEFAULT_HEALTH_POINTS
var game_time: int = DEFAULT_GAME_TIME
var pairs_count: int = DEFAULT_PAIRS_COUNT
var is_win: bool = false
