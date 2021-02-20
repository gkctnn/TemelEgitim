using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color
                {
                    Id=1,
                    Name="Red"
                }
            };
        }

        public void Add(Color color)
        {
            Color _color = _colors.SingleOrDefault(c => c.Id == color.Id);

            if (_color == null)
            {
                _colors.Add(_color);
            }
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.Id == color.Id);

            if (colorToDelete != null)
            {
                _colors.Remove(colorToDelete);
            }
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.Id == color.Id);

            if (colorToUpdate != null)
            {
                colorToUpdate.Name = color.Name;
            }
        }
    }
}
