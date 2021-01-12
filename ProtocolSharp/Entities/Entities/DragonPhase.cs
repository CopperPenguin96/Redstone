namespace ProtocolSharp.Entities.Entities
{
	public enum DragonPhase
	{
		Circling = 0,
		Strafing = 1, // Preparing to shoot a fireball
		FlyingToThePortalToLand = 2, // Part of transition to landed state
		LandingOnPortal = 3,
		TakingOffFromPortal = 4,
		LandedBreathAttack = 5,
		LandedLookingForPlayer = 6,
		LandedRoar = 7,
		ChargingPlayer = 8,
		FlyingToPortalToDie = 9,
		HoveringNoAI = 10 // Default when using the /summon command
	}
}