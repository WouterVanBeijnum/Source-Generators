using Aircraft.Operations.Engine;
using Components;
using Maintenance;
using Messages;

var aircraft = new Aircraft.Aircraft()
{
    Id = Guid.NewGuid(),
    Manufacturer = "Boeing",
    Model = "737 Max",
    Engines =
    [
        new AircraftEngine
        {
            Id = Guid.NewGuid(),
            Manufacturer = "Rolls-Royce",
        },
        new AircraftEngine
        {
            Id = Guid.NewGuid(),
            Manufacturer = "Rolls-Royce",
        }
    ]
};

Magic.Execute(new SetThrustCommand()
{
    Engine = aircraft.Engines.First(),
    Thrust = 5000,
});

Magic.Execute(new PowerEngineCommand()
{
    Engine = aircraft.Engines.First(),
    Enabled = true,
});

Magic.Execute(new PowerEngineCommand()
{
    Engine = aircraft.Engines.Last(),
    Enabled = true,
});

Magic.Execute(new SetThrustCommand()
{
    Engine = aircraft.Engines.First(),
    Thrust = 5000,
});

Magic.Execute(new SetThrustCommand()
{
    Engine = aircraft.Engines.Last(),
    Thrust = 9500,
});

Magic.Execute(new RegisterForMaintenanceCommand()
{
    AircraftToService = aircraft,
});

Magic.Execute(new PowerEngineCommand()
{
    Engine = aircraft.Engines.First(),
    Enabled = false,
});

Magic.Execute(new SetThrustCommand()
{
    Engine = aircraft.Engines.First(),
    Thrust = 0,
});

Magic.Execute(new PowerEngineCommand()
{
    Engine = aircraft.Engines.First(),
    Enabled = false,
});

Magic.Execute(new PowerEngineCommand()
{
    Engine = aircraft.Engines.Last(),
    Enabled = false,
});

Magic.Execute(new RegisterForMaintenanceCommand()
{
    AircraftToService = aircraft,
});
