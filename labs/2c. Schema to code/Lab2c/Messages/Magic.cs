using Aircraft.Operations.Engine;
using Maintenance;

namespace Messages;

internal static class Magic
{
    public static void Execute(PowerEngineCommand command)
    {
        if ((command.Engine.Power == null) != command.Enabled)
        {
            // Engine is already in the desired state.
            return;
        }

        if (command.Enabled)
        {
            Log("The engine has been started!");
            command.Engine.Power = 0;
            return;
        }

        if (command.Engine.Power != 0)
        {
            Log("Cannot power off the engine. Reduce thrust to 0 first!");
            return;
        }

        command.Engine.Power = null;
    }

    public static void Execute(SetThrustCommand command)
    {
        if (command.Engine.Power is null)
        {
            Log("Cannot set the thrust of the engine. The engines are still turned off. Please start your engines first!");
            return;
        }

        Log($"Engine thrust set to {command.Thrust}");
        command.Engine.Power = command.Thrust;

        if (command.Engine.Power > 9000)
        {
            Log("Oh no! The engine exploded!");
            command.Engine.Power = null;
        }
    }

    public static void Execute(RegisterForMaintenanceCommand command)
    {
        var aircraft = command.AircraftToService;

        if (aircraft.Engines.Any(e => e.Power != null))
        {
            Log("Please turn off your engines before submitting a maintenance request!");
            return;
        }

        Log($"Registering the maintenance for aircraft {aircraft.Manufacturer} {aircraft.Model}");
        Log("Also registering the aircraft engines for a checkup.");
        if (aircraft.Engines.Count == 0)
        {
            Log("Nevermind, the aircraft doesn't have engines.");
        }
    }

    private static void Log(string message)
    {
        Console.WriteLine(message);
        Task.Delay(2500).GetAwaiter().GetResult();
    }
}
