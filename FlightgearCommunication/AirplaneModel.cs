using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Simulation
{
    [Serializable()]
    public class AirplaneModel
    {
        private double _roll;
        private double _pitch;
        private double _yaw;

        private double _bearing;

        private double _rollDot;
        private double _pitchDot;

        private LatLng _position;
        private double _speed;

        private double _height;

        private double _aileronAngle;
        private double _elevatorAngle;

        private double _rollResponseFactor = 2.5;
        private double _pitchResponseFactor = 0.6;
        private double _yawResponseFactor = -0.7;

        private double _windX = 0.0;
        private double _windY = 0.2;

        public AirplaneModel(LatLng positionDeg)
        {
            _roll = 0.0;
            _pitch = 0.0;
            _yaw = 0.0;
            
            _rollDot = 0.0;
            _pitchDot = 0.0;

            _aileronAngle = 0.0;
            _elevatorAngle = 0.0;

            _speed = 13.0;
            _height = 100.0;

            _position = positionDeg;
        }

        public void Step(double dt)
        {
            double rollDotDot = _rollResponseFactor * _aileronAngle - _rollDot;
            _rollDot = _rollDot + rollDotDot * dt;
            _roll = _roll + _rollDot * dt;
            _roll = NormalizeAngle(_roll);

            double pitchDotDot = _pitchResponseFactor * _elevatorAngle - _pitchDot;
            _pitchDot = _pitchDot + pitchDotDot * dt;
            _pitch = _pitch + _pitchDot * dt;
            _pitch = NormalizeAngle(_pitch);

            double yawDot = -9.81 / _speed * Math.Tan(_yawResponseFactor * _roll);
            _yaw = _yaw + yawDot * dt;
            _yaw = NormalizeAngle(_yaw);

            double dx = _speed * Math.Sin(_yaw) * dt + _windX * dt;
            double dy = _speed * Math.Cos(_yaw) * dt + _windY * dt;

            _bearing = Math.Atan2(dx, dy);

            if (_yaw < 0.0)
                _yaw += Math.PI * 2.0;

            _position = new LatLng(_position.Lat + dy / LatLng.LatitudeMeterPerDegree, _position.Lng + dx / LatLng.LongitudeMeterPerDegree(_position.Lat));
        }

        public double NormalizeAngle(double a)
        {
            while (a > Math.PI * 2.0)
                a -= Math.PI * 2.0;
            while (a < -Math.PI * 2.0)
                a += Math.PI * 2.0;
            return a;
        }

        public double Roll
        {
            get { return _roll; }
            set { _roll = value; }
        }

        public double Pitch
        {
            get { return _pitch; }
            set { _pitch = value; }
        }

        public double Yaw
        {
            get { return _yaw; }
            set { _yaw = value; }
        }

        public LatLng Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }


        public double AileronAngle
        {
            get { return _aileronAngle; }
            set {
                if (value > Math.PI / 4)
                    _aileronAngle = Math.PI / 4;
                else if (value < -Math.PI / 4)
                    _aileronAngle = -Math.PI / 4;
                else
                    _aileronAngle = value; 
            }
        }

        public double ElevatorAngle
        {
            get { return _elevatorAngle; }
            set { _elevatorAngle = value; }
        }

        public double Bearing
        {
            get { return _bearing; }
        }

    }
}
