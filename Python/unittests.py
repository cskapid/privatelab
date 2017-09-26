#import resource
import unittest
import uuid


class TestSelfGarbageCollection(unittest.TestCase):

    def setUp(self):
        # Create an object that will use lots of memory
        self.large_list = []
        for _ in range(300000):
            self.large_list.append(uuid.uuid4())

    def tearDown(self):
        # Without the following line a copy of large_list will be kept in
        # memory for each test that runs, uncomment the line to allow the
        # large_list to be garbage collected.
        # self.large_list = None
        #mb_memory = resource.getrusage(resource.RUSAGE_SELF).ru_maxrss / 1000
        #print("Memory usage: %s MB" % mb_memory)
        pass

    def test_memory1(self):
        pass

    def test_memory2(self):
        pass

    def test_memory3(self):
        pass

    def test_memory4(self):
        pass

    def test_memory5(self):
        pass