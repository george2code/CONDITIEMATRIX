using System;
using System.Collections.Generic;
using System.Diagnostics;
using HCalc.Domain.Entities;
using HCalc.Domain.Enums;

namespace HCalc.Domain.Logic
{
    public class ConditionBuilder
    {
        private Dictionary<int, List<ExtentTable>> _incidenticallyDict;
        private Dictionary<int, List<ExtentTable>> _locallyDict;
        private Dictionary<int, List<ExtentTable>> _regularlyDict;
        private Dictionary<int, List<ExtentTable>> _frequentlyDict;
        private Dictionary<int, List<ExtentTable>> _generallyDict;

        public ConditionBuilder()
        {
            _incidenticallyDict = new Dictionary<int, List<ExtentTable>>()
            {
                {(int)IntencityType.Low, new List<ExtentTable>() {
                        new ExtentTable(1, ImportanceType.Critical),
                        new ExtentTable(1, ImportanceType.Serious),
                        new ExtentTable(1, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.Middle, new List<ExtentTable>() {
                        new ExtentTable(1, ImportanceType.Critical),
                        new ExtentTable(1, ImportanceType.Serious),
                        new ExtentTable(1, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.High, new List<ExtentTable>() {
                        new ExtentTable(2, ImportanceType.Critical),
                        new ExtentTable(1, ImportanceType.Serious),
                        new ExtentTable(1, ImportanceType.Minor)
                    }
                }
            };

            _locallyDict = new Dictionary<int, List<ExtentTable>>()
            {
                {(int)IntencityType.Low, new List<ExtentTable>() {
                        new ExtentTable(1, ImportanceType.Critical),
                        new ExtentTable(1, ImportanceType.Serious),
                        new ExtentTable(1, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.Middle, new List<ExtentTable>() {
                        new ExtentTable(2, ImportanceType.Critical),
                        new ExtentTable(1, ImportanceType.Serious),
                        new ExtentTable(1, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.High, new List<ExtentTable>() {
                        new ExtentTable(3, ImportanceType.Critical),
                        new ExtentTable(2, ImportanceType.Serious),
                        new ExtentTable(1, ImportanceType.Minor)
                    }
                }
            };

            _regularlyDict = new Dictionary<int, List<ExtentTable>>()
            {
                {(int)IntencityType.Low, new List<ExtentTable>() {
                        new ExtentTable(2, ImportanceType.Critical),
                        new ExtentTable(1, ImportanceType.Serious),
                        new ExtentTable(1, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.Middle, new List<ExtentTable>() {
                        new ExtentTable(3, ImportanceType.Critical),
                        new ExtentTable(2, ImportanceType.Serious),
                        new ExtentTable(1, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.High, new List<ExtentTable>() {
                        new ExtentTable(4, ImportanceType.Critical),
                        new ExtentTable(3, ImportanceType.Serious),
                        new ExtentTable(2, ImportanceType.Minor)
                    }
                }
            };

            _frequentlyDict = new Dictionary<int, List<ExtentTable>>()
            {
                {(int)IntencityType.Low, new List<ExtentTable>() {
                        new ExtentTable(3, ImportanceType.Critical),
                        new ExtentTable(2, ImportanceType.Serious),
                        new ExtentTable(1, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.Middle, new List<ExtentTable>() {
                        new ExtentTable(4, ImportanceType.Critical),
                        new ExtentTable(3, ImportanceType.Serious),
                        new ExtentTable(2, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.High, new List<ExtentTable>() {
                        new ExtentTable(5, ImportanceType.Critical),
                        new ExtentTable(4, ImportanceType.Serious),
                        new ExtentTable(3, ImportanceType.Minor)
                    }
                }
            };

            _generallyDict = new Dictionary<int, List<ExtentTable>>()
            {
                {(int)IntencityType.Low, new List<ExtentTable>() {
                        new ExtentTable(4, ImportanceType.Critical),
                        new ExtentTable(3, ImportanceType.Serious),
                        new ExtentTable(2, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.Middle, new List<ExtentTable>() {
                        new ExtentTable(5, ImportanceType.Critical),
                        new ExtentTable(4, ImportanceType.Serious),
                        new ExtentTable(3, ImportanceType.Minor)
                    }
                },
                {(int)IntencityType.High, new List<ExtentTable>() {
                        new ExtentTable(6, ImportanceType.Critical),
                        new ExtentTable(5, ImportanceType.Serious),
                        new ExtentTable(4, ImportanceType.Minor)
                    }
                }
            };
        }

        public int GetCondition(int extent, int intencity, int importance)
        {
            int result = 0;

            switch (extent)
            {
                case 1:         // Incidentically
                    result = CalculateCondition(intencity, importance, _incidenticallyDict);
                    break;
                case 2:         // Locally
                    result = CalculateCondition(intencity, importance, _locallyDict);
                    break;
                case 3:         // Regularly
                    result = CalculateCondition(intencity, importance, _regularlyDict);
                    break;
                case 4:         // Frequently
                    result = CalculateCondition(intencity, importance, _frequentlyDict);
                    break;
                case 5:         // Generally
                    result = CalculateCondition(intencity, importance, _generallyDict);
                    break;
                default:
                    break;
            }

            return result;
        }

        private int CalculateCondition(int intencity, int importance, Dictionary<int, List<ExtentTable>> dictionary)
        {
            int condition = 0;

            try
            {
                // get values by key = intencity
                var list = dictionary[intencity];

                // from values get current by importance
                foreach (var item in list) {
                    if (item.Importance == (ImportanceType) importance) {
                        condition = item.Value;
                        break;
                    }
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            return condition;
        }
    }
}